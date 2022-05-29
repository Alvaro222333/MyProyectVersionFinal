angular.module("login", [])
	.directive("login", ["Authentication", "$location",
		function (authentication, $location) {
			return {
				restrict: "E",
				replace: true,
				scope: {},
				link: function (scope) {
					scope.login = function () {
						authentication.token(scope.credentials,
							function (validated) {
								$location.path("/dashboard");
							},
							function () {
								
							});
					}
				},
				templateUrl: "Scripts/login/login.html"
			}
		}
	]);