(function () {
    var app = angular.module('app');

    var controllerId = 'test.views.students.list';
    app.controller(controllerId, [
        '$scope', '$uibModal', 'abp.services.app.student', 'abp.services.app.group',
        function ($scope, $uibModal, studentService, groupService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Test');

            vm.students = [];

            $scope.groups = [];

            $scope.addStudentShow = false;

            vm.sortSelect = null;

            $scope.groupSelect = null;

            $scope.student = {
                studentId: null,
                fullName: '',
                ci: null,
                age: null,
                assignedGroupId: null
            };

            $scope.$watch('groupSelect', function (value) {
                vm.refreshStudentList();
            });

            vm.refreshStudentList = function () {
                abp.ui.setBusy(
                    null,
                    studentService.getStudents({
                        assignedGroupId: $scope.groupSelect > 0 ? $scope.groupSelect : null
                    }).then(function (data) {
                        vm.students = data.data.items;
                    })
                );
            }

            vm.getStudentList = function () {
                abp.ui.setBusy(
                    null,
                    studentService.getAllStudents().then(function (data) {
                        vm.students = data.data.items;
                    })
                );
            };

            vm.getGroupList = function () {
                groupService.getAllGroup().then(function (data) {
                    $scope.groups = data.data.items;
                });
            }

            vm.getStudentCountText = function () {
                return abp.utils.formatString(vm.students.length);
            };

            vm.openStudentModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/students/studentModal.cshtml',
                    controller: 'test.views.student.studentModal as vm',
                    scope: $scope,
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    vm.getStudentList();
                });
            };

            vm.addStudent = function () {
                $scope.addStudentShow = true;
                $scope.student.fullName = '';
                $scope.student.ci = null;
                $scope.student.age = null;
                $scope.student.assignedGroupId = null;
                $scope.student.studentId = null;

                vm.openStudentModal();
            };

            vm.deleteStudent = function (index) {
                abp.message.confirm(
                    vm.localize('AreYouSureToDeleteStudent', vm.students[index].fullName),
                    vm.localize('AreYouSureMessage'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            studentService.deleteStudent(vm.students[index].id)
                                .then(function () {
                                    vm.getStudentList();
                                    abp.notify.info(abp.utils.formatString(vm.localize("StudentDeleteMessage")));
                                });
                        }
                    }
                );
            };

            vm.editStudent = function (index) {
                $scope.student.fullName = vm.students[index].fullName;
                $scope.student.ci = vm.students[index].ci;
                $scope.student.age = vm.students[index].age;
                $scope.student.assignedGroupId = vm.students[index].assignedGroupId;
                $scope.student.studentId = vm.students[index].id;
                $scope.addStudentShow = false;

                vm.openStudentModal();
            };

            vm.sortTo = function (input) {
                vm.sortSelect = input;
            };

            vm.getStudentList();

            vm.getGroupList();
        }
    ]);
})();