angular.module("teacher", [])
	.directive("teacher", [
		function () {
			return {
				restrict: "E",
				replace: true,
				scope: {
					handler: "=",
					teacher: "="
				},
				templateUrl: "Scripts/teacher/teacher.html"
			}
		}
	]);
