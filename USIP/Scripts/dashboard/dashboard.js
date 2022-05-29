angular.module("dashboard", [])
	.directive("dashboard", ["Api",
		function (api) {
			return {
				restrict: "E",
				replace: true,
				scope: {},
				link: function (scope) {
					function load() {
						api.student.get(
							function (response) {
								scope.length_students = response.students.length;
							}
						);
						api.course.get(
							function (response) {
								scope.length_courses = response.courses.length;
							}
						);
						api.subject.get(
							function (response) {
								scope.length_subjects = response.subjects.length;
							}
						);
						api.teacher.get(
							function (response) {
								scope.length_teachers = response.teachers.length;
							}
						);
					}


					load();
				},
				templateUrl: "Scripts/dashboard/dashboard.html"
			}
		}
	]);