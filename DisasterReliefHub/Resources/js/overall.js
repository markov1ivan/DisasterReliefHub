    $(function () {
        geocoder = new google.maps.Geocoder();
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position) {
            latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            //loadSafeWebMap()
        })
        var first_name = $("#safe_first_name"), last_name = $("#safe_last_name"),
          email = $("#safe_email"),
          allFields = $([]).add(name).add(email),
          tips = $(".validateTips");

        function updateTips(t) {
            tips
              .text(t)
              .addClass("ui-state-highlight");
            setTimeout(function () {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500);
        }

        function checkLength(o, n, min, max) {
            if (o.val().length > max || o.val().length < min) {
                o.addClass("ui-state-error");
                updateTips("Length of " + n + " must be between " +
                  min + " and " + max + ".");
                return false;
            } else {
                return true;
            }
        }

        function checkRegexp(o, regexp, n) {
            if (!(regexp.test(o.val()))) {
                o.addClass("ui-state-error");
                updateTips(n);
                return false;
            } else {
                return true;
            }
        }

        $("#iamsafe-form").dialog({
            autoOpen: false,
            height: 400,
            width: 800,
            modal: true,
            buttons: {
                "I AM SAFE!": function () {
                    var bValid = true;
                    allFields.removeClass("ui-state-error");

                    bValid = bValid && checkLength(name, "username", 3, 16);
                    bValid = bValid && checkLength(email, "email", 6, 80);
                    bValid = bValid && checkLength(password, "password", 5, 16);

                    bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");
                    // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/
                    bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");
                    bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");

                    if (bValid) {
                        $("#users tbody").append("<tr>" +
                          "<td>" + name.val() + "</td>" +
                          "<td>" + email.val() + "</td>" +
                          "<td>" + password.val() + "</td>" +
                        "</tr>");
                        $(this).dialog("close");
                    }
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                allFields.val("").removeClass("ui-state-error");
            }
        });

        $("#iamsafe_web_btn").click(function () {
            //retrieve_zip('getWebLocData')
            $("#iamsafe-form").dialog("open");
            loadSafeWebMap()
          });
    });

    function loadSafeWebMap() {
        var mapOptions = {
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        map = new google.maps.Map(document.getElementById("web_safe_map"), mapOptions);
        map.setCenter(latlng);
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    map.setZoom(15);
                    marker = new google.maps.Marker({
                        position: latlng,
                        map: map
                    });
                    $('#location').attr('title', results[0].formatted_address).html(results[0].formatted_address);
                    $('#safe_lat').val(results[0].geometry.location.lat());
                    $('#safe_lng').val(results[0].geometry.location.lng());
                }
            } else {
                alert("Geocoder failed due to: " + status);
            }
        });
    }

    function sendSafeMobEm() {
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    //infowindow.setContent(results[1].formatted_address);
                    window.open('mailto:disasterhub@gmail.com?subject=I am at Lat: ' + results[0].geometry.location.lat() + ', Lng: ' + results[0].geometry.location.lng() + '&body=I am safe! (edit message as desired)', '_blank')
                }
            } else {
                alert("Geocoder failed due to: " + status);
            }
        });
    }
