

    function onChangeCulture() {

        isPersianCulture = isChecked;


        if (localStorageSupport()) {
            localStorage.setItem("isPersianCulture", isPersianCulture);
        }

        location.reload();
    }



    $(function () {
        var isChecked = (isPersianCulture == 'true' || isPersianCulture == true);
        $("#ChangeCulture").prop('checked', isChecked);;
    });
