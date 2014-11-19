define("services/dataService1", [],
    function () {

        var testItems = [
            "item4",
            "item5",
            "item6"
        ];

        function getData() {
            return testItems;
        }

        return {
            getData: getData
        };
    }
);