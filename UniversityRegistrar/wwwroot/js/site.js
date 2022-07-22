const courseStudentsBtn = document.getElementById("course-students-button");
const courseDepartmentsBtn = document.getElementById("course-departments-button");
const courseStudentsDiv = document.getElementById("course-students-div");
const courseDepartmentsDiv = document.getElementById("course-departments-div");
// const departmentStudentsButton= document.getElementById("department-students-button");
// const departmentCoursesButton = document.getElementById("department-courses-button");
// const departmentStudentsDiv = document.getElementById("department-students-div");
// const departmentCoursesDiv = document.getElementById("department-courses-div");

courseStudentsBtn.addEventListener('click' , ()=>{
    courseStudentsDiv.classList.remove('d-none');
    courseDepartmentsDiv.classList.add('d-none');
});

courseDepartmentsBtn.addEventListener('click' , ()=>{
    courseDepartmentsDiv.classList.remove('d-none');
    courseStudentsDiv.classList.add('d-none');
});


// departmentStudentsButton.addEventListener('click' , ()=>{
//     departmentCoursesDiv.classList.add('d-none');
//     departmentStudentsDiv.classList.remove('d-none');
// });

// departmentCoursesButton.addEventListener('click' , ()=>{
//     departmentStudentsDiv.classList.add('d-none');
//     departmentCoursesDiv.classList.remove('d-none');
// });
