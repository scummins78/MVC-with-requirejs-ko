define("viewmodels/PartialTwoViewModel", ["ko", "services/dataService1"],
    function (ko, dataService) {
        return function PartialTwoViewModel() {

            var list = ko.observableArray();

            function addItem() {
                list.push("item" + list().length);
            }

            function init(bindControl) {
                list(dataService.getData());
                ko.applyBindings(this, bindControl);
            }

            return {
                list: list,
                addItem: addItem,
                init: init
            };
        };
    }
);