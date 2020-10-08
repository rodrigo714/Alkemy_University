
class Course {

    CourseRegister(){
        var data = new FormData();
        data.append('Input.Name',$("#inputName").val());
        data.append('Input.Description', $("#inputDesc").val());
        data.append('Input.Hours', $("#inputHours").val());
        data.append('Input.Status', document.getElementById("inputStatus").value);
        data.append('Input.CareerID', $("#inputCareer").val());

        $.ajax({
            url: "/Courses/GetCourses",
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            type: "post",
            success: (result) => {
                try {
                    var item = JSON.parse(result);
                    if (item.Code == "Done") {
                        window.location.href = "Index";
                    } else {
                        document.getElementById("message").innerHTML = item.Description;
                    }
                } catch{
                    document.getElementById("message").innerHTML = result;
                }
                console.log(result)
            }
        });
    }
}