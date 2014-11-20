define("viewmodels/PartialThreeViewModel", ["ko", "services/dataService2"],
    function (ko, dataService) {
        return function PartialTwoViewModel() {

            var list = ko.observableArray();

            function addItem() {
                list.push("stuff " + list().length);
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