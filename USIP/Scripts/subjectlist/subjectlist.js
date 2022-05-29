angular.module("subjectlist", [])
	.directive("subjectlist", ["Api", "$uibModal",
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
						template: "<subject handler='handler' subject='subject'></subject>"
					};

					function load() {
						
						api.subject.get(
							function (response) {
								scope.subjects = response.subjects;
							}
						);
					}

					scope.openEditor = function () {
						scope.subject = {};
						modal = $modal.open(config);
					};

					scope.handler = {
						save: function (data) {

							if (data.id != undefined) {
								api.subject.put(data,
									function (response) {
										load();
										modal.close();
									}, function () {
										alert("error del servidor");
									}
								);
							}
							else {
								api.subject.post(data,
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
							scope.subject = {};
							modal.close();
							load();
						}

					}

					scope.edit = function (subject) {
						scope.subject = subject;
						modal = $modal.open(config);
					};

					scope.delete = function (subject) {
						api.subject.delete(subject);
						setTimeout(function () {
							load();
						}, 1000);

					};

					load();
				},
				templateUrl: "Scripts/subjectlist/subjectlist.html"
			}
		}
	]);