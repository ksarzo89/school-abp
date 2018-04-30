(function () {
    var app = angular.module('app');

    var controllerId = 'test.views.group.list';
    app.controller(controllerId, [
        '$scope', '$uibModal', '$interval', 'abp.services.app.group',
        function ($scope, $uibModal, $interval, groupService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Test');

            vm.groups = [];

            $scope.addGroupShow = false;

            $scope.group = {
                groupId: 0,
                name: ''
            };

            vm.getGroupList = function () {
                abp.ui.setBusy(
                    null,
                    groupService.getAllGroup().then(function (data) {
                        vm.groups = data.data.items;
                    })
                );
            };

            vm.getGroupCountText = function () {
                return abp.utils.formatString(vm.groups.length);
            };

            vm.openGroupModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/groups/groupModal.cshtml',
                    controller: 'test.views.group.groupModal as vm',
                    scope: $scope,
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    vm.getGroupList();
                });
            };

            vm.addGroup = function () {
                $scope.group.groupId = null;
                $scope.group.name = '';
                $scope.addGroupShow = true;

                vm.openGroupModal();
            }

            vm.deleteGroup = function (index) {
                abp.message.confirm(
                    vm.localize('AreYouSureToDeleteGroup', vm.groups[index].name),
                    vm.localize('AreYouSureMessage'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            groupService.deleteGroup(vm.groups[index].id).then(function () {
                                abp.notify.success(vm.localize('GroupDeleteMessage'));
                                vm.getGroupList();
                            });
                        }
                    }
                );
            };

            vm.editGroup = function (index) {
                $scope.group.name = vm.groups[index].name;
                $scope.group.groupId = vm.groups[index].id;
                $scope.addGroupShow = false;

                vm.openGroupModal();
            };

            vm.showGroupCount = function () {
                abp.notify.info(vm.localize('GroupTotalMessage', vm.groups.length));
            }

            vm.getGroupList();

            $interval(function () { vm.showGroupCount(); }, 60000);

        }
    ]);
})();