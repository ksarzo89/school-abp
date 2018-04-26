(function () {
    var app = angular.module('app');

    var controllerId = 'test.views.students.list';
    app.controller(controllerId, [
        '$scope', 'abp.services.app.student', 'abp.services.app.group',
        function ($scope, studentService, groupService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Test');

            vm.students = [];

            vm.groups = [];

            vm.addStudent = false;

            vm.editStudent = false;

            vm.sortSelect = null;

            vm.student = {
                studentId: null,
                fullName: '',
                ci: null,
                age: null,
                assignedGroupId: null
            };

            abp.ui.setBusy(null, studentService.getAllStudents().then(function (data) {
                vm.students = data.data.students;
            }));

            groupService.getAllGroup().then(function (data) {
                vm.groups = data.data.groups;
            });

            vm.getStudentList = function () {
                abp.ui.setBusy(
                    null,
                    studentService.getAllStudents().then(function (data) {
                        vm.students = data.data.students;
                    })
                );
            };

            vm.getStudentCountText = function () {
                return abp.utils.formatString(vm.students.length);
            };

            vm.setAddStudent = function () {
                vm.addStudent = true;
                vm.editStudent = false;
                vm.student.fullName = '';
                vm.student.ci = null;
                vm.student.age = null;
                vm.student.assignedGroupId = null;
                vm.student.studentId = null;
            };

            vm.addStudentF = function () {
                abp.ui.setBusy(
                    null,
                    studentService.createStudent(
                        vm.student
                    ).then(function () {
                        vm.addStudent = false;
                        vm.getStudentList();
                        abp.notify.info(abp.utils.formatString(vm.localize("StudentCreatedMessage")));
                    })
                );
            };

            vm.deleteStudent = function (index) {
                abp.ui.setBusy(
                    null,
                    studentService.deleteStudent(vm.students[index].id)
                        .then(function () {
                            vm.getStudentList();
                            abp.notify.info(abp.utils.formatString(vm.localize("StudentDeleteMessage")));
                        })
                );

                /*abp.message.confirm(
                    vm.localize("StudentDeleteMessageConfirm"),
                    vm.localize("QuestionConfirm"),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            studentService.deleteStudent(vm.students[index].id).then(function () {
                                vm.getStudentList();
                                abp.notify.info(abp.utils.formatString(vm.localize("StudentDeleteMessage")));
                            });
                        }
                    }
                );*/
            };

            vm.enableEditStudent = function (index) {
                vm.student.fullName = vm.students[index].fullName;
                vm.student.ci = vm.students[index].ci;
                vm.student.age = vm.students[index].age;
                vm.student.assignedGroupId = vm.students[index].assignedGroupId;
                vm.student.studentId = vm.students[index].id;
                vm.addStudent = true;
                vm.editStudent = true;
            };

            vm.editStudentF = function () {
                abp.ui.setBusy(
                    null,
                    studentService.updateStudent(
                        vm.student
                    ).then(function () {
                        vm.addStudent = false;
                        vm.editStudent = false;
                        vm.getStudentList();
                        abp.notify.info(abp.utils.formatString(vm.localize("StudentEditMessage")));
                    })
                );
            };

            vm.sortTo = function (input)
            {
                vm.sortSelect = input;
            };
        }
    ]);
})();