angular.module("subject", [])
	.directive("subject", [
		function () {
			return {
				restrict: "E",
				replace: true,
				scope: {
					handler: "=",
					subject: "="
				},
				templateUrl: "Scripts/subject/subject.html"
			}
		}
	]);
