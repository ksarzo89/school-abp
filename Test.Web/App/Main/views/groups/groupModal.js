(function () {
    var app = angular.module('app');
    var controllerId = 'test.views.group.groupModal';
    app.controller(controllerId, [
        '$scope', '$uibModalInstance', 'abp.services.app.group',
        function ($scope, $uibModalInstance, groupService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Test');

            vm.saving = false;

            vm.save = function () {
                vm.saving = true;

                if ($scope.addGroupShow) {
                    groupService.createGroup(
                        $scope.group
                    ).then(function () {
                        abp.notify.info(vm.localize('GroupCreatedMessage'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }
                else {
                    groupService.updateGroup(
                        $scope.group
                    ).then(function () {
                        abp.notify.info(vm.localize('GroupEditMessage'));
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