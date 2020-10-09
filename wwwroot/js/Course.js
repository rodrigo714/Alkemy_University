
class Course {
    constructor() {
        this.CourseID = 0;
    }

    CourseRegister(){
        var data = new FormData();
        data.append('Input.Name',$("#inputName").val());
        data.append('Input.Description', $("#inputDesc").val());
        data.append('Input.Hours', $("#inputHours").val());
        data.append('Input.Status', document.getElementById("inputStatus").value);
        data.append('Input.CareerID', $("#inputCareer").val());
        data.append('Input.CourseID', $("#inputID").val());

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
                        window.location.href = "/Courses/Index";
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

    CourseEdit(course, career) {
        let j = 1;
        $("#inputName").val(course.Name);
        $("#inputDesc").val(course.Description);
        $("#inputStatus").prop("checked", course.Status);
        $("#inputHours").val(course.Hours);
        $("#inputID").val(course.CourseID);

        let x = document.getElementById("inputCareer");
        x.options.length = 0;
        for (var i = 0; i < career.length; i++) {
            if (career[i].Value == course.CareerID) {
                x.options[0] = new Option(career[i].Text, career[i].Value);
                x.selectedIndex = 0;
                j = i;
            } else {
                x.options[i] = new Option(career[i].Text, career[i].Value);
            }
        }
        x.options[j] = new Option(career[0].Text, career[0].Value);

        console.log(course);
        console.log(career);
    }

    Reset() {
        document.getElementById("inputName").value = "";
        document.getElementById("inputDesc").value = "";
        document.getElementById("inputStatus").checked = false;
        document.getElementById("inputHours").value = 0;
        document.getElementById("inputCareer").value = null;
    }
}