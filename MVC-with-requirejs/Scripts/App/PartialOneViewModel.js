
define("viewmodels/PartialOneViewModel", ["ko"],
    function (ko) {
        return function PartialOneViewModel() {

            var mainMessage = ko.observable("Hello!");

            function updateMessage() {
                mainMessage("Goodbye!");
            };
            function init(bindControl) {
                ko.applyBindings(this, bindControl);
            }

            return {
                displayMessage: mainMessage,
                
                updateMessage: updateMessage,
                init: init
            };
        };
    }
);