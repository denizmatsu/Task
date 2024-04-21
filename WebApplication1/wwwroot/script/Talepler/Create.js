$(document).ready(function () {
    var requestData = {
        url: '/Talepler/GetComments',
        method: 'GET',
        data: null,
        showNotification: false
    };

        sendRequest(requestData.url, requestData.method, requestData.data, requestData.showNotification)
        .then(function (response) {
            var customers = response.data;
            var optionsHtml = '';
            $.each(customers, function (index, customer) {
                optionsHtml += '<option value="' + customer.id + '">' + customer.name + '</option>';
            });
            $('#customerId').html(optionsHtml);
        })
        .catch(function (error) {
            console.log(error)
        });
    


    $('#comment-form').submit(function (e) {
        e.preventDefault(); // Normal form gönderimini engelle

        // Form validasyonu
        if (this.checkValidity() === false) {
            e.stopPropagation();
        } else {
            var customerId = $('#customerId').val();
            var complaint = $('#complaint').val();

            var data = {
                CustomerId: customerId,
                Complaint: complaint
            };
            var requestData = {
                url: '/Talepler/Create',
                method: 'POST',
                data: data,
                showNotification: true
            };
            sendRequest(requestData.url, requestData.method, requestData.data, requestData.showNotification)
                .then(function (response) {
                })
                .catch(function (error) {
                });
        }

        $(this).addClass('was-validated');
    });

});