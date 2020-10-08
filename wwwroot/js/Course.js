
class Course {

    CourseRegister(){
        var data = new FormData();
        data.append('Input.Name',$("inputName").val());
        data.append('Input.Description', $("inputDesc").val());
        data.append('Input.Hours', $("inputHours").val());
        data.append('Input.Status', $("inputStatus").val());
        data.append('Input.CareerID', $("inputCareer").val());

        $.ajax({
            url: "/Courses/GetCourses",
            data: data,
            cache: false,
            type: "post",
            success: (result) => {
                console.log(result)
            }
        });
    }
}