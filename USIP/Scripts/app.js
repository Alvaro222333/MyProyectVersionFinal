"use-strict"
angular
	.module("App", [
		//bower modules
		"angular-confirm",
		"ngAnimate",
		"ngCookies",
		"ngIdle",
		"ngMaterial",
		"ngResource",
		"ngRoute",
		"ngSanitize",
		"ui.bootstrap",
		"ui.router",
		//Custome modules
		"home",
		"student",
		"classlist",
		"course",
		"dashboard",
		"subjectlist",
		"subject",
		"teacher",
		"teacherlist",
		"login",
		"menu",
		"coursesubjectlist",
	])
	.controller("AppCtrl", ["Authentication", "$scope", "$window", "$location","$http",
		function (authentication, $scope, $window, $location, $http) {
			var existingUser = $window.sessionStorage.getItem("LoggedInUser");
			if (existingUser) {
				var user = angular.fromJson(existingUser);
				angular.extend(authentication.loggedUser, user);
				$http.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
			} else {
				$location.path("/login")
			}

			$scope.hide = function () {
				return !authentication.isLoggedIn();
			};
		}
	])
	.config(["$stateProvider", "$urlRouterProvider", "$httpProvider",
		function ($stateProvider, $urlRouterProvider, $httpProvider) {
			$httpProvider.interceptors.push("ErrorInterceptor");

			$stateProvider
				.state("home", {
					url: "/home",
					template: "<home></home>"
				})
				.state("student", {
					url: "/student",
					template: "<student></student>"
				})
				.state("classlist", {
					url: "/classlist",
					template: "<classlist></classlist>"
				})
				.state("course", {
					url: "/course",
					template: "<course></course>"
				})
				.state("dashboard", {
					url: "/dashboard",
					template: "<dashboard></dashboard>"
				})

				.state("subjectlist", {
					url: "/subjectlist",
					template: "<subjectlist></subjectlist>"
				})
				.state("subject", {
					url: "/subject",
					template: "<subject></subject>"
				})
				.state("teacher", {
					url: "/teacher",
					template: "<teacher></teacher>"
				})
				.state("teacherlist", {
					url: "/teacherlist",
					template: "<teacherlist></teacherlist>"
				})
				.state("coursesubjectlist", {
					url: "/coursesubjectlist",
					template: "<coursesubjectlist></coursesubjectlist>"
				})

				.state("login", {
					url: "/login",
					template: "<login></login>"
				});

			$urlRouterProvider.otherwise("/login")
		}
	])
	.service("Api", ["$resource", "$http",
		function ($resource, $http) {
			this.student = $resource("../api/student", null, {
				"get": { method: "GET" },
				"post": { method: "POST" },
				"put": { method: "PUT" },
				"delete": { method: "DELETE" }
			});
			this.course = $resource("../api/course", null, {
				"get": { method: "GET" },
				"post": { method: "POST" },
				"put": { method: "PUT" },
				"delete": { method: "DELETE" }
			});
			this.subject = $resource("../api/subject", null, {
				"get": { method: "GET" },
				"post": { method: "POST" },
				"put": { method: "PUT" },
				"delete": { method: "DELETE" }
			});
			this.teacher = $resource("../api/teacher", null, {
				"get": { method: "GET" },
				"post": { method: "POST" },
				"put": { method: "PUT" },
				"delete": { method: "DELETE" }
			});
			this.courseSubject = $resource("../api/courseSubject", null, {
				"get": { method: "GET" },
				"post": { method: "POST" },
				"put": { method: "PUT" },
				"delete": { method: "DELETE" }
			});
			this.course2 = $resource("../api/course/id", null, {
				"post": { method: "POST" }
			});
			this.student2 = $resource("../api/student/id", null, {
				"post": { method: "POST" }
			});
			this.subject2 = $resource("../api/subject/id", null, {
				"post": { method: "POST" }
			});
			this.study = $resource("../api/study", null, {
				"get": { method: "GET" },
				"post": { method: "POST" },
				"put": { method: "PUT" },
				"delete": { method: "DELETE" }
			});

			this.token = function (data) {
				return $http({
					method: "POST",
					url: "/Token",
					data: data,
					headers: {
						"Content-Type": "application/x-www-form-urlencoded"
					}
				});
			}
		}
	])
	.factory("Authentication", ["Api", "$http", "$window",
		function (api, $http, $window) {
			var freshUser = function () {
				return {
					username: "",
					access_token: ""
				}
			}
			var authenticatedUser = new freshUser();

			function extend(user) {
				angular.extend(authenticatedUser, user);
			}

			return {
				loggedUser: authenticatedUser,
				token: function (credentials, success, failed) {
					var data = "grant_type=password&username=" + credentials.user + "&password=" + credentials.password;
					api.token(data).then(function (response) {
						extend(response.data);
						$http.defaults.headers.common["Authorization"] = "Bearer " + response.data.access_token;
						$window.sessionStorage.setItem("LoggedInUser", angular.toJson(authenticatedUser));
						success(response);
					}, function () {
						failed();
					})
				},
				isLoggedIn: function () {
					return authenticatedUser.access_token != "";
				},
				loggingOff: function (success) {
					extend(freshUser());
					$window.sessionStorage.removeItem("LoggedInUser")
					delete $http.defaults.headers.common["Authorization"];
					success();
				}
			};
		}
	])
	.factory("ErrorInterceptor", ["$q",
		function ($q) {
			return {
				"responseError": function (response) {
					if ((response.status === 500) && (_.isObject(response.data))) {
						alert(response.data.Message);
					}
					return $q.reject(response);
				}
			};
		}
	]);