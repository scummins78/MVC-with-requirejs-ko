define("services/dataService2", [],
    function () {

        var testItems = [
            "item1",
            "item2",
            "item3"
        ];

        function getData() {
            return testItems;
        }

        return {
            getData: getData
        };
    }
);