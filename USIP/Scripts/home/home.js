angular.module("home", [])
	.directive("home", ["Api", "Authentication", "$uibModal",
		function (api, authentication, $modal) {
			return {
				restrict: "E",
				replace: true,
				scope: {},
				link: function (scope) {
					var modal;
					var config = {
						scope: scope,
						backdrop: "static",
						template: "<student handler='handler' student='student'></student>"
					};

					function load() {
						api.student.get(
							function (response) {
								scope.students = response.students;
							}
						);
					}

					scope.openEditor = function () {
						scope.student = {};
						modal = $modal.open(config);
					};

					scope.handler = {
						save: function (data) {

							if (data.id != undefined) {
								api.student.put(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}
							else {
								api.student.post(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}

						},
						close: function (data) {
							scope.student = {};
							modal.close();
							load();
						}
					}

					scope.edit = function (student) {
						scope.student = student;
						modal = $modal.open(config);
					};

					scope.delete = function (student) {
						api.student.delete(student);
						setTimeout(function () {
							load();
						}, 1000);

					};
					scope.logOut = function () {
						authentication.loggingOff();
					}

					load();
				},
				templateUrl: "Scripts/home/home.html"
			}
		}
	]);