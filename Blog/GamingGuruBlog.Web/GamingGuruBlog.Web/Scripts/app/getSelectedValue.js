    $(document).ready(function () {
        $(document.body).on('change', '.Users', function (event) {
            var selectedRoleID = $(this).val();
            var selectedUserID = event.target.id;
            var formData = {
                userId: selectedUserID,
                roleId: selectedRoleID
            };
            $.ajax({
                type: "POST",
                url: "http://localhost:53596/Admin/UserRole",
                data: {
                    'userId' : selectedUserID,
                    'roleId' : selectedRoleID},
                //contentType: "application/json; charset=utf-8",
                dataType: "JSON",
                success: function (data) {
                    alert (data.FirstName + " " + data.LastName + " has been gvien role: " + data.Role.Name)
                },
                failure: function (response) {
                    alert("Something went wrong: " + response.respnseText);
                },
                error: function (response) {
                    alert("There was an error: " + response.Error);
                }
            })
           
        });
    });