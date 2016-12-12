$(document).ready(function () {
    $('#postForm').validate({
        rules: {
            Title: {
                required: true,
                rangelength: [1,100]
            },
            Body: {
                required: true
            },
            Summary: {
                required: true,
                rangelength: [1,500]
            },
            AssignedCategories: {
                required: true
            }

        }
    });
});