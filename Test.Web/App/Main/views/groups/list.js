(function () {
    var app = angular.module('app');

    var controllerId = 'test.views.group.list';
    app.controller(controllerId, [
        '$scope', 'abp.services.app.group',
        function ($scope, groupService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Test');

            vm.groups = [];

            vm.addGroup = false;

            vm.editGroup = false;

            vm.group = {
                groupId: 0,
                name: ''
            };

            abp.ui.setBusy(null, groupService.getAllGroup().then(function (data) {
                vm.groups = data.data.groups;
            }));

            vm.getGroupList = function () {
                abp.ui.setBusy(
                    null,
                    groupService.getAllGroup().then(function (data) {
                        vm.groups = data.data.groups;
                    })
                );
            };

            vm.getGroupCountText = function () {
                return abp.utils.formatString(vm.groups.length);
            };

            vm.setAddGroup = function () {
                vm.addGroup = true;
                vm.editGroup = false;
                vm.group.name = '';
                vm.group.id = 0;
            };

            vm.addGroupF = function () {
                abp.ui.setBusy(
                    null,
                    groupService.createGroup(
                        vm.group
                    ).then(function () {
                        vm.addGroup = false;
                        vm.getGroupList();
                        abp.notify.info(abp.utils.formatString(vm.localize("GroupCreatedMessage")));
                    })
                );
            };

            vm.deleteGroup = function (index) {
                abp.ui.setBusy(
                    null,
                    groupService.deleteGroup(vm.groups[index].id)
                        .then(function () {
                            vm.getGroupList();
                            abp.notify.info(abp.utils.formatString(vm.localize("GroupDeleteMessage")));
                        })
                );
            };

            vm.enableEditGroup = function (index) {
                vm.group.name = vm.groups[index].name;
                vm.group.groupId = vm.groups[index].id;
                vm.addGroup = true;
                vm.editGroup = true;
            };

            vm.editGroupF = function () {
                abp.ui.setBusy(
                    null,
                    groupService.updateGroup(
                        vm.group
                    ).then(function () {
                        vm.addGroup = false;
                        vm.editGroup = false;
                        vm.getGroupList();
                        abp.notify.info(abp.utils.formatString(vm.localize("GroupEditMessage")));
                    })
                );
            };
        }
    ]);
})();