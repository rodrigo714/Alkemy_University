
class Career {

    CareerRegister() {
        $.post(
            "/Careers/GetCareer",
            $(".formCareer").serialize(),
            (response) => {
                console.log(response);
                try {
                    var item = JSON.parse(response);
                    if (item.Code == "Done") {
                        window.location.href = "/Careers/Index";
                    } else {
                        $("#message").innerHTML(item.Description);
                    }
                    console.log(response);
                } catch (e) {
                    $("#message").text(response);
                }
            }
         );
    }

    CareerEdit(data) {
        document.getElementById("inputName").value = data.Name;
        document.getElementById("inputDesc").value = data.Description;
        document.getElementById("inputStatus").value = data.Status;
        console.log(data);
    }
}