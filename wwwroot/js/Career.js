
class Career {

    constructor(){
        this.CareerID = 0;
    }

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
                        document.getElementById("message").innerHTML(item.Description);
                    }
                    console.log(response);
                } catch (e) {
                    document.getElementById("message").text(response);
                }
            }
         );
    }

    CareerEdit(data) {
        document.getElementById("inputName").value = data.Name;
        document.getElementById("inputDesc").value = data.Description;
        document.getElementById("inputStatus").checked = data.Status;
        document.getElementById("inputID").value = data.CareerID;
        console.log(data);
    }

    CareerGet(data) {
        document.getElementById("titleCareer").innerHTML = data.Name;
        this.CareerID = data.CareerID;
    }

    CareerDelete() {
        $.post(
            "/Careers/DeleteCareer",
            { CareerID: this.CareerID },
            (response) => {
                console.log(response);
                var item = JSON.parse(response);
                if (item.Code == "Done") {
                    window.location.href = "/Careers/Index";
                } else {
                    document.getElementById("messageDelete").innerHTML = item.Description;
                }
            }
        );
    }

    Reset() {
        document.getElementById("inputName").value = "";
        document.getElementById("inputDesc").value = "";
        document.getElementById("inputStatus").checked = false;
        document.getElementById("inputID").value = 0;
    }
}