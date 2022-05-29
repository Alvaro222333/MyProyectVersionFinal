angular.module("student", [])
	.directive("student", [
		function () {
			return {
				restrict: "E",
				replace: true,
				scope: {
					handler: "=",
					student: "="
				},
				templateUrl: "Scripts/student/student.html"
			}
		}
	]);