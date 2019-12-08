class SwalUtility {
    static Success() {

        window.swal({
            type: 'success',
            title: 'Əməliyyat yerinə yetirildi',
            showConfirmButton: false,
            timer: 1000
        });
    }
    static Success(res) {

        window.swal({
            type: 'success',
            title: res.totalPrice,
            showConfirmButton: false,
            timer: 1000
        });
    }

    static Fail() {
        window.swal({
            type: 'error',
            title: 'Xəta baş verdi',
            showConfirmButton: false,
            timer: 1000
        });
    }

    static Fail(text) {
        window.swal({
            type: 'error',
            title: text,
            showConfirmButton: false,
            timer: 2000
        });
    }
}