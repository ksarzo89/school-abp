(function () {
    var app = angular.module('app');
    var controllerId = 'test.views.student.studentModal';
    app.controller(controllerId, [
        '$scope', '$uibModalInstance', 'abp.services.app.student',
        function ($scope, $uibModalInstance, studentService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Test');

            vm.saving = false;

            vm.save = function () {
                vm.saving = true;

                if ($scope.addStudentShow) {
                    studentService.createStudent(
                        $scope.student
                    ).then(function () {
                        abp.notify.info(abp.utils.formatString(vm.localize("StudentCreatedMessage")));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }
                else {
                    studentService.updateStudent(
                        $scope.student
                    ).then(function () {
                        abp.notify.info(abp.utils.formatString(vm.localize("StudentEditMessage")));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();