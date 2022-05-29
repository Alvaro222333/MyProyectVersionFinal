angular.module("classlist", [])
	.directive("classlist", ["Api", "$uibModal",
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
						template: "<course handler='handler' course='course'></course>"
					};

					function load() {
						api.course.get(
							function (response) {
								scope.courses = response.courses;
							}
						);
					}

					scope.openEditor = function () {
						
						modal = $modal.open(config);
					};

					scope.handler = {
						save: function (data) {
							//alert(JSON.stringify(data));
							if (data.id != undefined) {
								api.course.put(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}
							else {
								api.course.post(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}

						},
						close: function (data){
							
							modal.close();
							load();
						}
					}

					scope.edit = function (course) {
						scope.course = course;
						modal = $modal.open(config);
					};

					scope.delete = function (course) {
						api.course.delete(course);
						setTimeout(function () {
							load();
						}, 1000);

					};
					load();
				},
				templateUrl: "Scripts/classlist/classlist.html"
			}
		}
	]);