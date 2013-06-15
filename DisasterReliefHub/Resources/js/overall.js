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
                        $('#iamsafe-form form').submit()
                        $(this).dialog("close");
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
