
define("Scripts/App/PageOneViewModel", ["ko", "services/dataService1"],
    function (ko, dataService) {
        return function PageOneViewModel() {

            var mainMessage = ko.observable("Hello!");
            var list = ko.observableArray();

            function updateMessage() {
                mainMessage("Goodbye!");
            };
            function addItem() {
                list.push("item" + list().length);
            }

            function init(bindControl) {
                list(dataService.getData());
                ko.applyBindings(this, bindControl);
            }

            return {
                displayMessage: mainMessage,
                list: list,
                
                addItem: addItem,
                updateMessage: updateMessage,
                init: init
            };
        };
    }
);