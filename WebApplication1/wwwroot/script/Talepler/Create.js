const populateCustomerOptions = async function (customers) {
    var optionsHtml = '';
    $.each(customers, function (index, customer) {
        optionsHtml += '<option value="' + customer.id + '">' + customer.name + '</option>';
    });
    $('#customerId').html(optionsHtml);
};

const handleCommentFormSubmit = async function () {
    $('#comment-form').submit(async function (e) {
        e.preventDefault();

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
            try {
                await sendRequest(requestData.url, requestData.method, requestData.data, requestData.showNotification);
                $('#complaint').val('');
            } catch (error) {
                console.error(error);
            }
        }
        $(this).addClass('was-validated');
    });
};

const GetComment = async function () {
    var requestData = {
        url: '/Talepler/GetComments',
        method: 'GET',
        data: null,
        showNotification: false
    };

    sendRequest(requestData.url, requestData.method, requestData.data, requestData.showNotification)
        .then(function (response) {
            populateCustomerOptions(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });

    handleCommentFormSubmit();
};

$(document).ready(function () {
    GetComment();
});
