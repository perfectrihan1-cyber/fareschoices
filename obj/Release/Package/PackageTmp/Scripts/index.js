//https://images.unsplash.com/photo-1495822892661-2ead864e1c7b?auto=format&fit=crop&w=2689&q=80
//https://images.unsplash.com/photo-1490380169520-0a4b88d52565?auto=format&fit=crop&w=1950&q=80
//https://images.unsplash.com/photo-1499561385668-5ebdb06a79bc?auto=format&fit=crop&w=1949&q=80
//Using jQuery on my actual project, but this could've 
//been rewritten without it
var one_way_bool = true;


$(function () {

    $("#loader").hide()
    $(".one_way_btn").click(function () {
        $(".one_way_btn").css({
            "background-color": "black",
            "color": "white"
        });
        $(".round_trip_btn").css({
            "background-color": "transparent",
            "color": "black"
        });


        one_way_bool = true;

        $("#date-picker").css({
            "position": "absolute",
            "width": "200px",
            "color": "white",
            "left": "445px"
        });
        $("#from_auto").css({
            "width": "200px",
            "color": "white",
            "left": "0px"
        });
        $("#to_auto").css({
            "width": "200px",
            "color": "white",
            "left": "235px"
        });

        $("#search_btn").css({
            "left": "670px"
        });




        $(".datepicker-input").show()
        $(".daterangepicker-input").hide()
        $(".datepicker-input").empty()
        $(".daterangepicker-input").empty()
        $(".datepicker-input").each(function (i) {
            flatpickr("#" + this.id, {
                allowInput: true,
                enableTime: false,
                dateFormat: "y-m-d"
            });

        });

    });
    $(".round_trip_btn").click(function () {
        one_way_bool = false;
        $(".round_trip_btn").css({
            "background-color": "black",
            "color": "white"
        });

        //adjust positions of input and button tag
        $("#range-picker").css({
            "position": "absolute",
            "width": "390px",
            "color": "white",
            "left": "360px"
        });
        $("#from_auto").css({
            "width": "150px",
            "color": "white",
            "left": "0px"
        });
        $("#to_auto").css({
            "width": "180px",
            "color": "white",
            "left": "170px"
        });

        $("#search_btn").css({
            "left": "760px"
        });




        $(".one_way_btn").css({
            "background-color": "transparent",
            "color": "black"
        });
        $(".daterangepicker-input").attr("placeholder", "Date")
        $(".datepicker-input ").hide()
        $(".daterangepicker-input").show()
        $(".daterangepicker-input").empty()
        $(".datepicker-input").empty()
        $(".daterangepicker-input").each(function (i) {
            flatpickr("#" + this.id, {
                allowInput: true, //On or off doesn't change error
                enableTime: false,
                dateFormat: "y-m-d",
                mode: "range"
            });


        });

    });

});



var options = {
    shouldSort: true,
    threshold: 0.4,
    maxPatternLength: 32,
    keys: [{
        name: 'iata',
        weight: 0.5
    }, {
        name: 'name',
        weight: 0.3
    }, {
        name: 'city',
        weight: 0.2
    }]
};

var fuse;
if (typeof Fuse !== 'undefined' && typeof airports !== 'undefined') {
    fuse = new Fuse(airports, options);
}

// ═════════════════════════════════════════════════════════════════
// DEPARTURE (FROM) AUTOCOMPLETE
// ═════════════════════════════════════════════════════════════════
var ac = $('.autocomplete_from')
    .on('click', function (e) {
        e.stopPropagation();
    })
    .on('focus keyup', search)
    .on('keydown', onKeyDown);

var wrap = $('<div>')
    .addClass('autocomplete-wrapper')
    .insertBefore(ac)
    .append(ac);

var list = $('<div>')
    .addClass('autocomplete-results')
    .hide()
    .on('click', '.autocomplete-result', function (e) {
        e.preventDefault();
        e.stopPropagation();
        selectIndex($(this).data('index'));
    })
    .on('mouseenter', '.autocomplete-result', function () {
        var idx = parseInt($(this).data('index'), 10);
        if (!isNaN(idx)) {
            selectedIndex = idx;
            list.find('.autocomplete-result').removeClass('highlighted');
            $(this).addClass('highlighted');
            list.attr('data-highlight', idx);
        }
    })
    .appendTo(wrap);

var results = [];
var numResults = 0;
var selectedIndex = -1;

function clearResults() {
    results = [];
    numResults = 0;
    selectedIndex = -1;
    list.empty().removeAttr('data-highlight').removeClass('open').hide();
}

function selectIndex(index) {
    if (results && results.length > index && index >= 0) {
        var r = results[index];
        ac.val(r.iata + "-" + r.name + " " + r.city).trigger('change');
        clearResults();
        if (typeof ac_to !== 'undefined' && ac_to.length && !ac_to.val().trim()) {
            setTimeout(function () { ac_to.focus(); }, 50);
        }
    }
}

function search(e) {
    if (!fuse) {
        if (typeof Fuse !== 'undefined' && typeof airports !== 'undefined') {
            fuse = new Fuse(airports, options);
        } else {
            return;
        }
    }

    if (e.which === 38 || e.which === 13 || e.which === 40 || e.which === 27 || e.which === 9) {
        return;
    }

    clearResults_to();

    var q = ac.val().trim();
    if (q.length > 0) {
        results = _.take(fuse.search(q), 8);
        numResults = results.length;

        if (numResults === 0) {
            list.html('<div style="padding:14px;color:#64748b;font-size:13px;text-align:center;"><i class="fa-solid fa-circle-exclamation" style="margin-right:6px;color:#94a3b8;"></i>No airports found for "' + $('<div>').text(q).html() + '"</div>')
                .addClass('open')
                .show();
            return;
        }

        var divs = results.map(function (r, i) {
            return '<div class="autocomplete-result" data-index="' + i + '">' +
                '<div class="ac-icon"><i class="fa-solid fa-plane-departure"></i></div>' +
                '<div class="ac-details">' +
                    '<div class="ac-title"><span class="ac-code-inline">' + r.iata + '</span> &middot; ' + r.name + '</div>' +
                    '<div class="ac-location"><i class="fa-solid fa-location-dot" style="font-size:10px;margin-right:5px;opacity:0.7;"></i>' + r.city + (r.country ? ', ' + r.country : '') + '</div>' +
                '</div>' +
                '<div class="ac-iata-pill">' + r.iata + '</div>' +
                '</div>';
        });

        selectedIndex = -1;
        list.html(divs.join(''))
            .attr('data-highlight', selectedIndex)
            .addClass('open')
            .show();

    } else {
        clearResults();
    }
}

function onKeyDown(e) {
    if (e.which === 27) {
        clearResults();
        e.stopPropagation();
        return;
    }

    if (numResults === 0) return;

    switch (e.which) {
        case 38: // up arrow
            selectedIndex--;
            if (selectedIndex < 0) {
                selectedIndex = numResults - 1;
            }
            updateHighlight(list, selectedIndex);
            e.preventDefault();
            e.stopPropagation();
            break;

        case 40: // down arrow
            selectedIndex++;
            if (selectedIndex >= numResults) {
                selectedIndex = 0;
            }
            updateHighlight(list, selectedIndex);
            e.preventDefault();
            e.stopPropagation();
            break;

        case 13: // Enter
        case 9:  // Tab
            if (selectedIndex >= 0 && selectedIndex < numResults) {
                selectIndex(selectedIndex);
                if (e.which === 13) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            } else if (numResults > 0) {
                selectIndex(0);
                if (e.which === 13) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            }
            break;

        default:
            return;
    }
}

// ═════════════════════════════════════════════════════════════════
// ARRIVAL (TO) AUTOCOMPLETE
// ═════════════════════════════════════════════════════════════════
var ac_to = $('.autocomplete_to')
    .on('click', function (e) {
        e.stopPropagation();
    })
    .on('focus keyup', search_to)
    .on('keydown', onKeyDown_to);

var wrap_to = $('<div>')
    .addClass('autocomplete-wrapper')
    .insertBefore(ac_to)
    .append(ac_to);

var list_to = $('<div>')
    .addClass('autocomplete-results_to')
    .hide()
    .on('click', '.autocomplete-result', function (e) {
        e.preventDefault();
        e.stopPropagation();
        selectIndex_to($(this).data('index'));
    })
    .on('mouseenter', '.autocomplete-result', function () {
        var idx = parseInt($(this).data('index'), 10);
        if (!isNaN(idx)) {
            selectedIndex_to = idx;
            list_to.find('.autocomplete-result').removeClass('highlighted');
            $(this).addClass('highlighted');
            list_to.attr('data-highlight', idx);
        }
    })
    .appendTo(wrap_to);

var results_to = [];
var numResults_to = 0;
var selectedIndex_to = -1;

function clearResults_to() {
    results_to = [];
    numResults_to = 0;
    selectedIndex_to = -1;
    list_to.empty().removeAttr('data-highlight').removeClass('open').hide();
}

function selectIndex_to(index) {
    if (results_to && results_to.length > index && index >= 0) {
        var r = results_to[index];
        ac_to.val(r.iata + "-" + r.name + " " + r.city).trigger('change');
        clearResults_to();
        var depDate = $('#flight_from_date');
        if (depDate.length && !depDate.val().trim()) {
            setTimeout(function () { depDate.focus(); }, 50);
        }
    }
}

function search_to(e) {
    if (!fuse) {
        if (typeof Fuse !== 'undefined' && typeof airports !== 'undefined') {
            fuse = new Fuse(airports, options);
        } else {
            return;
        }
    }

    if (e.which === 38 || e.which === 13 || e.which === 40 || e.which === 27 || e.which === 9) {
        return;
    }

    clearResults();

    var q = ac_to.val().trim();
    if (q.length > 0) {
        results_to = _.take(fuse.search(q), 8);
        numResults_to = results_to.length;

        if (numResults_to === 0) {
            list_to.html('<div style="padding:14px;color:#64748b;font-size:13px;text-align:center;"><i class="fa-solid fa-circle-exclamation" style="margin-right:6px;color:#94a3b8;"></i>No airports found for "' + $('<div>').text(q).html() + '"</div>')
                .addClass('open')
                .show();
            return;
        }

        var divs = results_to.map(function (r, i) {
            return '<div class="autocomplete-result" data-index="' + i + '">' +
                '<div class="ac-icon"><i class="fa-solid fa-plane-arrival"></i></div>' +
                '<div class="ac-details">' +
                    '<div class="ac-title"><span class="ac-code-inline">' + r.iata + '</span> &middot; ' + r.name + '</div>' +
                    '<div class="ac-location"><i class="fa-solid fa-location-dot" style="font-size:10px;margin-right:5px;opacity:0.7;"></i>' + r.city + (r.country ? ', ' + r.country : '') + '</div>' +
                '</div>' +
                '<div class="ac-iata-pill">' + r.iata + '</div>' +
                '</div>';
        });

        selectedIndex_to = -1;
        list_to.html(divs.join(''))
            .attr('data-highlight', selectedIndex_to)
            .addClass('open')
            .show();

    } else {
        clearResults_to();
    }
}

function onKeyDown_to(e) {
    if (e.which === 27) {
        clearResults_to();
        e.stopPropagation();
        return;
    }

    if (numResults_to === 0) return;

    switch (e.which) {
        case 38: // up arrow
            selectedIndex_to--;
            if (selectedIndex_to < 0) {
                selectedIndex_to = numResults_to - 1;
            }
            updateHighlight(list_to, selectedIndex_to);
            e.preventDefault();
            e.stopPropagation();
            break;

        case 40: // down arrow
            selectedIndex_to++;
            if (selectedIndex_to >= numResults_to) {
                selectedIndex_to = 0;
            }
            updateHighlight(list_to, selectedIndex_to);
            e.preventDefault();
            e.stopPropagation();
            break;

        case 13: // Enter
        case 9:  // Tab
            if (selectedIndex_to >= 0 && selectedIndex_to < numResults_to) {
                selectIndex_to(selectedIndex_to);
                if (e.which === 13) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            } else if (numResults_to > 0) {
                selectIndex_to(0);
                if (e.which === 13) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            }
            break;

        default:
            return;
    }
}

function updateHighlight($container, idx) {
    $container.attr('data-highlight', idx);
    var $items = $container.find('.autocomplete-result');
    $items.removeClass('highlighted');
    if (idx >= 0 && idx < $items.length) {
        var $active = $items.eq(idx).addClass('highlighted');
        if ($active.length && $active[0].scrollIntoView) {
            $active[0].scrollIntoView({ block: 'nearest' });
        }
    }
}

$(document).on('click', function (e) {
    if (!$(e.target).closest(wrap).length) {
        clearResults();
    }
    if (!$(e.target).closest(wrap_to).length) {
        clearResults_to();
    }
});
