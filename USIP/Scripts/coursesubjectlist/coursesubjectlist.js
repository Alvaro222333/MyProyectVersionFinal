angular.module("coursesubjectlist", [])
	.directive("coursesubjectlist", ["Api", "$uibModal",
		function (api, $modal) {
			return {
				restrict: "E",
				replace: true,
				scope: {},
				link: function (scope) {
					var modal;

					function load() {

						api.courseSubject.get(
							function (response) {
								scope.courseSubjects = response.courseSubjects;

								for (const element of scope.courseSubjects) {
									loadDetail(element);
								}
							}
						);
						api.course.get(
							function (response) {
								scope.courses = response.courses;
							}
						);
						api.subject.get(
							function (response) {
								scope.subjects = response.subjects;
							}
						);
						api.student.get(
							function (response) {
								scope.students = response.students;
							}
						);

						api.study.get(
							function (response) {
								scope.studies = response.studies;

								for (const study of scope.studies) {
									loadStudy(study);
								}
							}
						);
					}
					function loadDetail(element) {
						api.subject2.post(element.idSubject,
							function (response2) {
								element.subject = (response2.data);
							}
						);
						api.course2.post(element.idCourse,
							function (response2) {
								element.course = (response2.data);
							}
						);
					}
					function loadStudy(element) {
						api.course2.post(element.idCourse,
							function (response2) {
								element.course = (response2.data);
							}
						);
						api.student2.post(element.idStudent,
							function (response2) {
								element.student = (response2.data);
							}
						);
					}
					scope.openEditor = function () {
						
						
					};

					scope.save = function (data) {
						api.courseSubject.post(data,
							function (response) {
								load();
							}, function () {
								alert("error del servidor");
							}
						);

					};
					scope.saveStudy = function (data) {
						api.study.post(data,
							function (response) {
								load();
							}, function () {
								alert("error del servidor");
							}
						);

					};

					scope.delete = function (courseSubject) {
						api.courseSubject.delete(courseSubject);
						setTimeout(function () {
							load();
						}, 1000);

					};

					load();
				},
				templateUrl: "Scripts/coursesubjectlist/coursesubjectlist.html"
			}
		}
	]);