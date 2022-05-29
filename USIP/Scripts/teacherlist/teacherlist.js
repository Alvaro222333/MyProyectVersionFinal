angular.module("teacherlist", [])
	.directive("teacherlist", ["Api", "$uibModal",
		function (api, $modal) {
			return {
				restrict: "E",
				replace: true,
				scope: {},
				link: function (scope) {
					var modal;
					var config = {
						scope: scope,
						backdrop: "static",
						template: "<teacher handler='handler' teacher='teacher'></teacher>"
					};

					function load() {

						api.teacher.get(
							function (response) {
								scope.teachers = response.teachers;
							}
						);
					}

					scope.openEditor = function () {
						scope.teacher = {};
						modal = $modal.open(config);
					};

					scope.handler = {
						save: function (data) {

							if (data.id != undefined) {
								api.teacher.put(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}
							else {
								api.teacher.post(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}

						}
						,
						close: function (data) {
							scope.teacher = {};
							modal.close();
							load();
						}

					}

					scope.edit = function (teacher) {
						scope.teacher = teacher;
						modal = $modal.open(config);
					};

					scope.delete = function (teacher) {
						api.teacher.delete(teacher);
						setTimeout(function () {
							load();
						}, 1000);

					};

					load();
				},
				templateUrl: "Scripts/teacherlist/teacherlist.html"
			}
		}
	]);