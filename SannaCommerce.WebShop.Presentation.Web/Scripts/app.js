$(document).ready(function () {
    var app = angular
        .module('app', [])
        .controller("Orders", ['$scope', function ($scope) {
            $scope.details = dataDetails;
            $scope.addOrderDetail = function () {
                var product = {
                    name: angular.element('#idProduct option:selected').text(),
                    id: angular.element('#idProduct option:selected').val()
                };
                $scope.details.push({ IdProduct: product.id, NameProduct: product.name, QuantityProducts: $scope.quantity });
                $scope.quantity = '';
                angular.element('#idProduct option[value=""]').prop('selected', true);
            };
            $scope.deleteOrderDetail = function (id) {
                var details = [];
                angular.forEach($scope.details, function (value, key) {
                    if (value.IdProduct != id) {
                        details.push(value);
                    }
                });
                $scope.details = details;
            };
        }]);

    $('.datatable').DataTable();

    $('.save-changes').click(function () {
        var name = $(this).data('name');

        if (localStorage.getItem('sessionModels')) {
            var sessionModels = JSON.parse(localStorage.getItem('sessionModels')) || [];
            delete sessionModels[name];
            localStorage.setItem('sessionModels', JSON.stringify(sessionModels));
        }
    });
});
function PendingChanges(pendingSession) {
    // Validate Pending Changes
    if (pendingSession) {
        if (localStorage.getItem('sessionModels')) {
            var sessionModels = JSON.parse(localStorage.getItem('sessionModels')) || [];
            var separator = "";
            $('.pending-text').html('');
            $.each(sessionModels, function (key, item) {
                var pendingText = '<a href="' + item.url + '">' + separator + item.name + '</a>';
                separator = ", ";
                $('.pending-text').append(pendingText);
            });
        }
    }
    // Update session server with LocalStorage data
    else {
        if (localStorage.getItem('pendingSave') && JSON.parse(localStorage.getItem('pendingSave'))) {
            if (localStorage.getItem('sessionModels')) {
                var sessionModels = JSON.parse(localStorage.getItem('sessionModels')) || [];
                var separator = "";
                $('.pending-text').html('');
                $.each(sessionModels, function (key, item) {
                    $.ajax({
                        type: 'POST',
                        url: item.urlSync,
                        dataType: 'json',
                        async: false,
                        data: { jsonObject: item.model },
                        success: function (result) {
                            var pendingText = '<a href="' + item.url + '">' + separator + item.name + '</a>';
                            separator = ", ";
                            $('.pending-text').append(pendingText);
                        },
                        error: function (jqXHR, exception) {
                            console.log(jqXHR, exception);
                        }
                    });
                });
                updateLinks = true;
            }
            localStorage.setItem('pendingSave', false);
            location.reload(true);
        }
    }
}
function UpdateLocalStorageModels(data) {
    if (data.name && data.url && data.urlSync && data.model) {
        localStorage.setItem('pendingSave', true);
        if (localStorage.getItem('sessionModels')) {
            var sessionModels = JSON.parse(localStorage.getItem('sessionModels')) || {};
            delete sessionModels[data.name];
            sessionModels[data.name] =  data;
            localStorage.setItem('sessionModels', JSON.stringify(sessionModels));
            var separator = "";
            $('.pending-text').html('');
            $.each(sessionModels, function (key, item) {
                var pendingText = '<a href="' + item.url + '">' + separator + item.name + '</a>';
                separator = ", ";
                $('.pending-text').append(pendingText);
            });
        }
        else {
            var sessionModels = {};
            sessionModels[data.name] = data;
            localStorage.setItem('sessionModels', JSON.stringify(sessionModels));
            $('.pending-text').html('<a href="' + data.url + '">' + data.name + '</a>');
        }

    }
}