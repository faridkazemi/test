(function () {
    angular.module('app').controller('tweetCtrl', ['$scope', 'toaster', 'tweetService',
    	function ($scope, toaster, tweetService) {

    	    $scope.DataStatusFinTechAustralia = 'Loading';
    	    $scope.DataStatusFinTech = 'Loading';
    	    populateFinTechTweets();
    	    populateFinTechAustraliaTweets();
    	  

    	    //--------------------- Implementation  ----------------------

    	    function populateFinTechTweets() {

    	        $scope.Model = {}
    	        tweetService.GetRecents('#fintech', function (data) {

    	            $scope.Model.FinTech = data;
    	            $scope.DataStatusFinTech = 'Loaded';
    	        });
    	    }

    	    function populateFinTechAustraliaTweets() {

    	        tweetService.GetRecents('#fintechaustralia', function (data) {

    	            $scope.Model.FinTechAustralia = data;
    	            $scope.DataStatusFinTechAustralia = 'Loaded';
    	        });
    	    }

    	}]);
})();