(function () {
    angular.module('app').factory('tweetService', ['$resource', 'toaster', tweetService]);

    function tweetService($resource, toaster) {
        var dataFactory = {};

        dataFactory.GetRecents = function (hashtagParam, func) {

            $resource('home/GetRecents').get({ hashtag: hashtagParam }, func, genericError);
        };
		
        //-------------------- Private Helper methods ----------------------
        function genericError(error) {
            toaster.error({ body: "Operation Failed !" });
        }
        return dataFactory;
    };

})();