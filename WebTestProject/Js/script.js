function AddEmployee() {
    var Id = $("#Id").val();
    var FName = $("#FirstName").val();
    var LName = $("LastName").val();
    var CityId = $("CityId").val();
    $.ajax({
        url: "/Ajax/EmployesAdd?Id=" + Id + "&fName=" + FName + "&lName=" + LName + "&CityId=" + CityId + "CityId",
        metod: "GET",
        success: function (res) {
            console.log(res);
            res = JSON.parse(res)
            if (res.ResultCode == 0) {
                toastr.success(res.ResultDescription);
            } else {
                toastr.error(res.ResultDescription);
            }
        },
        error: function (err) {
            toastr.error(err);
            console.error(err);
        }
    });
}

