// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

const server = "https://localhost:51044/";
const dealerurl = server + 'api/dealers';



window.onload = function () {

    let dealer_dropdown = document.getElementById('dealers-dropdown');
    dealer_dropdown.length = 0;

    let defaultOption = document.createElement('option');
    defaultOption.text = 'Choose dealer';
    defaultOption.value = 0;

    dealer_dropdown.add(defaultOption);
    dealer_dropdown.selectedIndex = 0;


    fetch(dealerurl, {
        method: 'GET',
    })
        .then(
            function (response) {
                if (response.status !== 200) {
                    console.warn('Looks like there was a problem. Status Code: ' + response.status);
                    return;
                }
                // Examine the text in the response  
                response.json().then(function (data) {
                    let option;

                    for (let i = 0; i < data.length; i++) {
                        option = document.createElement('option');
                        option.text = data[i].dealerName;
                        option.value = data[i].id;
                        dealer_dropdown.add(option);
                    }
                });
            }
        )
        .catch(function (err) {
            console.error('Fetch Error -', err);
        });

}
$(document).ready(function () {

    var ajaxCallParams = {};
    var ajaxDataParams = {};

    function ajaxCall(callParams, dataParams, callback) {
        $.ajax({
            type: callParams.Type,
            url: callParams.Url,
            quietMillis: 100,
            dataType: callParams.DataType,
            data: dataParams,
            cache: true,
            success: function (response) {
                callback(response);
            },
            error: function (response) {
                callback(response);
            }
        });
    }


    var dealerdrpdown = document.getElementById("dealers-dropdown");
    var sortingdrpdown = document.getElementById("sorting-dropdown");

    dealerdrpdown.addEventListener("change", getDealerDeailsToDisplay);
    sortingdrpdown.addEventListener("change", getDealerDeailsToDisplay);

    function getDealerDeailsToDisplay() {
        if (parseInt(dealerdrpdown.value) === 0) {
            document.getElementById("CarList").innerHTML = "Please select Dealer";
        }
        if (parseInt(dealerdrpdown.value) !== 0) {

            ajaxCallParams.Type = "GET";
            ajaxCallParams.Url = "/index/DealerCars";
            ajaxCallParams.DataType = "json";

            // Set Data parameters 
            ajaxDataParams.Guid = dealerdrpdown.value;
            ajaxDataParams.DealerName = dealerdrpdown.options[dealerdrpdown.options.selectedIndex].text;
            ajaxDataParams.Sorting = "";
            if (parseInt(sortingdrpdown.value) !== 0) {
                ajaxDataParams.Sorting = sortingdrpdown.value;
            }
            // Passing call and data parameters to general Ajax function
            ajaxCall(ajaxCallParams, ajaxDataParams, function (result) {
                if (result.length > 0) {
                    var html = "<table style='width: 100%' border='1'>";
                    html += "<caption>American Automobiles </caption>";
                    html += "<tr>";
                    html += "<th>Make Name</th>";
                    html += "<th>Make Model</th>";
                    html += "<th>Mileage</th>";
                    html += "<th>Price</th>";
                    html += "<th>Color</th>";
                    html += "<th>Status</th>";
                    html += "</tr>";
                    for (var i = 0; i < result.length; i++) {
                        html += "<tr>";
                        html += "<td>" + result[i].makeName + "</td>";
                        html += "<td>" + result[i].modelName + "</td>";
                        html += "<td>" + result[i].mileage + "</td>";
                        html += "<td>$" + result[i].price + "</td>";
                        html += "<td>" + result[i].carColor + "</td>";
                        html += "<td>" + result[i].carStatus + "</td>";
                        html += "</tr>";
                    }
                    html += "</table>";
                    document.getElementById("CarList").innerHTML = html;
                }
                else {
                    document.getElementById("CarList").innerHTML = "No Records for Dealers";
                }
            });
        }

    }


});