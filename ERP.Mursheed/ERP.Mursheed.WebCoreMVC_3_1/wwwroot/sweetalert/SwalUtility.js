class SwalUtility {
    static Success() {

        swal({
            type: 'success',
            title: 'Əməliyyat yerinə yetirildi',
            showConfirmButton: false,
            timer: 1000
        });
    }

    static Fail() {
        swal({
            type: 'error',
            title: 'Xəta baş verdi',
            showConfirmButton: false,
            timer: 1000
        });
    }

    static Fail(text) {
        swal({
            type: 'error',
            title: text,
            showConfirmButton: false,
            timer: 2000
        });
    }
}