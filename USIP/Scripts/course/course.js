angular.module("course", [])
	.directive("course", [
		function () {
			return {
				restrict: "E",
				replace: true,
				scope: {
					handler: "=",
					course: "="
				},
				templateUrl: "Scripts/course/course.html"
			}
		}
	]);