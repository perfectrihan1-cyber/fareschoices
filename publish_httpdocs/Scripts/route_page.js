/**
 * FARESRADAR - Route & Content Page Modern Enhancer
 * Dynamically enhances all 35+ route landing pages with interactive accordions,
 * route highlights, table wrappers, search engine pre-fills, and CTA banners.
 */
document.addEventListener("DOMContentLoaded", function () {
    if (window.__routePageEnhanced) return;
    window.__routePageEnhanced = true;

    var col = document.querySelector(".container1 .column");
    if (!col) return;

    // Check if this is a route page (has hero and flight content)
    var hero = document.querySelector(".hero");
    var headline = document.querySelector(".hero-headline");
    var isRoutePage = headline && (
        headline.textContent.toLowerCase().indexOf("flights") !== -1 ||
        headline.textContent.toLowerCase().indexOf("to") !== -1
    );

    // 1. Add Route Badge Pill if not already present
    if (hero && headline && isRoutePage && !hero.querySelector(".route-badge-pill")) {
        var badge = document.createElement("div");
        badge.className = "route-badge-pill";
        badge.innerHTML = '<i class="fa-solid fa-plane-departure"></i> Popular Route &bull; Verified Airline Schedules';
        hero.insertBefore(badge, headline);
    }

    // 2. Pre-fill Search Engine Inputs if on a specific flight route
    var routeAirports = {
        "atlanta-to-hawaii": { from: "ATL - Hartsfield-Jackson Atlanta Intl, Atlanta", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "atlanta-to-rome": { from: "ATL - Hartsfield-Jackson Atlanta Intl, Atlanta", to: "FCO - Leonardo da Vinci-Fiumicino, Rome" },
        "austin-to-london": { from: "AUS - Austin-Bergstrom Intl, Austin", to: "LHR - London Heathrow Airport, London" },
        "chicago-to-greece": { from: "ORD - Chicago O'Hare Intl Airport, Chicago", to: "ATH - Eleftherios Venizelos, Athens" },
        "chicago-to-madrid": { from: "ORD - Chicago O'Hare Intl Airport, Chicago", to: "MAD - Adolfo Suarez Madrid-Barajas, Madrid" },
        "philadelphia-to-hawaii": { from: "PHL - Philadelphia Intl Airport, Philadelphia", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "pittsburgh-to-london": { from: "PIT - Pittsburgh Intl Airport, Pittsburgh", to: "LHR - London Heathrow Airport, London" },
        "cincinnati-to-bonaire": { from: "CVG - Cincinnati/Northern Kentucky, Cincinnati", to: "BON - Flamingo Intl Airport, Bonaire" },
        "dallas-to-london": { from: "DFW - Dallas/Fort Worth Intl, Dallas", to: "LHR - London Heathrow Airport, London" },
        "denver-to-paris": { from: "DEN - Denver Intl Airport, Denver", to: "CDG - Charles de Gaulle Airport, Paris" },
        "miami-to-madrid": { from: "MIA - Miami Intl Airport, Miami", to: "MAD - Adolfo Suarez Madrid-Barajas, Madrid" },
        "miami-to-paris": { from: "MIA - Miami Intl Airport, Miami", to: "CDG - Charles de Gaulle Airport, Paris" },
        "newark-to-hawaii": { from: "EWR - Newark Liberty Intl Airport, Newark", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "new-york-to-greece": { from: "JFK - John F Kennedy Intl, New York", to: "ATH - Eleftherios Venizelos, Athens" },
        "new-york-to-hawaii": { from: "JFK - John F Kennedy Intl, New York", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "san-diego-to-london": { from: "SAN - San Diego Intl Airport, San Diego", to: "LHR - London Heathrow Airport, London" },
        "seattle-to-paris": { from: "SEA - Seattle-Tacoma Intl, Seattle", to: "CDG - Charles de Gaulle Airport, Paris" },
        "sacramento-to-maui": { from: "SMF - Sacramento Intl Airport, Sacramento", to: "OGG - Kahului Airport, Maui" },
        "salt-lake-city-to-hawaii": { from: "SLC - Salt Lake City Intl, Salt Lake City", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "boston-to-dublin": { from: "BOS - Boston Logan Intl Airport, Boston", to: "DUB - Dublin Airport, Dublin" },
        "seattle-to-maui": { from: "SEA - Seattle-Tacoma Intl, Seattle", to: "OGG - Kahului Airport, Maui" },
        "boston-to-ireland": { from: "BOS - Boston Logan Intl Airport, Boston", to: "DUB - Dublin Airport, Dublin" },
        "boston-to-iceland": { from: "BOS - Boston Logan Intl Airport, Boston", to: "KEF - Keflavik Intl Airport, Reykjavik" },
        "boston-to-london": { from: "BOS - Boston Logan Intl Airport, Boston", to: "LHR - London Heathrow Airport, London" },
        "chicago-to-iceland": { from: "ORD - Chicago O'Hare Intl Airport, Chicago", to: "KEF - Keflavik Intl Airport, Reykjavik" },
        "las-vegas-to-hawaii": { from: "LAS - Harry Reid Intl Airport, Las Vegas", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "las-vegas-to-honolulu": { from: "LAS - Harry Reid Intl Airport, Las Vegas", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "miami-to-lima": { from: "MIA - Miami Intl Airport, Miami", to: "LIM - Jorge Chavez Intl, Lima" },
        "sacramento-to-hawaii": { from: "SMF - Sacramento Intl Airport, Sacramento", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "salt-lake-city-to-cancun": { from: "SLC - Salt Lake City Intl, Salt Lake City", to: "CUN - Cancun Intl Airport, Cancun" },
        "salt-lake-city-to-new-york": { from: "SLC - Salt Lake City Intl, Salt Lake City", to: "JFK - John F Kennedy Intl, New York" },
        "san-diego-to-boston": { from: "SAN - San Diego Intl Airport, San Diego", to: "BOS - Boston Logan Intl Airport, Boston" },
        "new-york-to-iceland": { from: "JFK - John F Kennedy Intl, New York", to: "KEF - Keflavik Intl Airport, Reykjavik" },
        "phoenix-to-hawaii": { from: "PHX - Phoenix Sky Harbor Intl, Phoenix", to: "HNL - Daniel K Inouye Intl, Honolulu" },
        "los-angeles-to-hawaii": { from: "LAX - Los Angeles Intl Airport, Los Angeles", to: "HNL - Daniel K Inouye Intl, Honolulu" }
    };

    var path = window.location.pathname.toLowerCase().replace(/^\/|\/$/g, "");
    if (path.indexOf("flights-from-") === 0) {
        var slug = path.replace("flights-from-", "");
        if (routeAirports[slug]) {
            var fromInput = document.getElementById("flight_from");
            var toInput = document.getElementById("flight_to");
            if (fromInput && (!fromInput.value || fromInput.value.trim() === "")) {
                fromInput.value = routeAirports[slug].from;
            }
            if (toInput && (!toInput.value || toInput.value.trim() === "")) {
                toInput.value = routeAirports[slug].to;
            }
        }
    }

    // 3. Wrap all tables in a responsive wrapper
    var tables = col.querySelectorAll("table");
    tables.forEach(function (tbl) {
        if (!tbl.parentElement.classList.contains("table-responsive-wrapper")) {
            var wrapper = document.createElement("div");
            wrapper.className = "table-responsive-wrapper";
            tbl.parentNode.insertBefore(wrapper, tbl);
            wrapper.appendChild(tbl);
        }
    });

    // 4. Extract Route Quick Facts if this is a route page with route details
    if (isRoutePage && !document.querySelector(".route-quick-facts")) {
        var routeInfoTable = null;
        tables.forEach(function (t) {
            var text = t.textContent.toLowerCase();
            if (text.indexOf("departure airport") !== -1 || text.indexOf("flight time") !== -1) {
                routeInfoTable = t;
            }
        });

        if (routeInfoTable) {
            var depAirport = "", arrAirport = "", flightTime = "", distance = "";
            var rows = routeInfoTable.querySelectorAll("tr");
            rows.forEach(function (r) {
                var cells = r.querySelectorAll("td");
                if (cells.length >= 2) {
                    var k = cells[0].textContent.trim().toLowerCase();
                    var v = cells[1].textContent.trim();
                    if (k.indexOf("departure") !== -1) depAirport = v;
                    else if (k.indexOf("arrival") !== -1) arrAirport = v;
                    else if (k.indexOf("flight time") !== -1) flightTime = v;
                    else if (k.indexOf("distance") !== -1) distance = v;
                }
            });

            if (flightTime || distance || depAirport) {
                // Format flight time cleanly (e.g. ~9h 30m – 10h)
                var formattedTime = flightTime ? flightTime
                    .replace(/hours?/gi, "h")
                    .replace(/minutes?/gi, "m")
                    .replace(/\s+to\s+/gi, " &ndash; ")
                    .replace(/approximately|approx\./gi, "~")
                    .replace(/^~\s+/, "~")
                    .trim() : "Nonstop &amp; 1-Stop";

                // Format distance cleanly (e.g. 5,000 mi (8,050 km))
                var formattedDistance = distance ? distance
                    .replace(/miles?/gi, "mi")
                    .replace(/approximately|approx\./gi, "~")
                    .replace(/^~\s+/, "~")
                    .trim() : "Direct Route";

                var factsContainer = document.createElement("div");
                factsContainer.className = "route-quick-facts";
                factsContainer.innerHTML = 
                    '<div class="route-facts-grid">' +
                        '<div class="fact-item theme-time">' +
                            '<div class="fact-icon-wrap"><i class="fa-solid fa-clock"></i></div>' +
                            '<div class="fact-info">' +
                                '<div class="fact-label">Flight Duration</div>' +
                                '<div class="fact-value" title="' + flightTime + '">' + formattedTime + '</div>' +
                            '</div>' +
                        '</div>' +
                        '<div class="fact-item theme-distance">' +
                            '<div class="fact-icon-wrap"><i class="fa-solid fa-route"></i></div>' +
                            '<div class="fact-info">' +
                                '<div class="fact-label">Route Distance</div>' +
                                '<div class="fact-value" title="' + distance + '">' + formattedDistance + '</div>' +
                            '</div>' +
                        '</div>' +
                        '<div class="fact-item theme-scanned">' +
                            '<div class="fact-icon-wrap"><i class="fa-solid fa-plane-circle-check"></i></div>' +
                            '<div class="fact-info">' +
                                '<div class="fact-label"><span class="live-pulse-dot"></span> Fares Scanned</div>' +
                                '<div class="fact-value">500+ Airlines Live</div>' +
                            '</div>' +
                        '</div>' +
                        '<div class="fact-item theme-phone">' +
                            '<div class="fact-icon-wrap"><i class="fa-solid fa-phone-volume"></i></div>' +
                            '<div class="fact-info">' +
                                '<div class="fact-label">Phone Discounts</div>' +
                                '<div class="fact-value">' +
                                    '<a href="tel:+18332636016" class="fact-phone-btn">+1-833-263-6016 <span class="fact-call-tag">24/7 Call</span></a>' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                    '</div>';

                if (hero && hero.nextSibling) {
                    hero.parentNode.insertBefore(factsContainer, hero.nextSibling);
                }
            }
        }
    }

    // 5. Add Quick Navigation Jump Bar at top of article
    if (isRoutePage && !col.querySelector(".route-nav-bar")) {
        // Tag main sections with clean anchor IDs
        var allH2 = col.querySelectorAll("h2");
        allH2.forEach(function (h) {
            var txt = h.textContent.toLowerCase();
            if (txt.indexOf("overview") !== -1) h.id = "sec-overview";
            else if (txt.indexOf("airline") !== -1) h.id = "sec-airlines";
            else if (txt.indexOf("season") !== -1) h.id = "sec-seasonality";
            else if (txt.indexOf("airport") !== -1) h.id = "sec-airports";
            else if (txt.indexOf("frequently asked") !== -1) h.id = "sec-faq";
        });

        var navBar = document.createElement("div");
        navBar.className = "route-nav-bar";
        navBar.innerHTML = 
            '<button type="button" class="route-nav-pill active" onclick="jumpSection(\'sec-overview\', event)"><i class="fa-solid fa-compass"></i> Overview</button>' +
            '<button type="button" class="route-nav-pill" onclick="jumpSection(\'sec-airlines\', event)"><i class="fa-solid fa-plane"></i> Airlines</button>' +
            '<button type="button" class="route-nav-pill" onclick="jumpSection(\'sec-seasonality\', event)"><i class="fa-solid fa-calendar-days"></i> Best Months</button>' +
            '<button type="button" class="route-nav-pill" onclick="jumpSection(\'sec-airports\', event)"><i class="fa-solid fa-building"></i> Airports</button>' +
            '<button type="button" class="route-nav-pill" onclick="jumpSection(\'sec-faq\', event)"><i class="fa-solid fa-circle-question"></i> FAQs</button>';

        col.insertBefore(navBar, col.firstChild);

        // Add Route Insights Tip right after first overview heading
        var firstH2 = document.getElementById("sec-overview") || col.querySelector("h2");
        if (firstH2 && !col.querySelector(".route-insights-box")) {
            var insightsBox = document.createElement("div");
            insightsBox.className = "route-insights-box";
            insightsBox.innerHTML = 
                '<div class="insights-icon"><i class="fa-solid fa-lightbulb"></i></div>' +
                '<div class="insights-content">' +
                    '<h4>Smart Booking Tip for This Route</h4>' +
                    '<p>Midweek departures (Tuesday &amp; Wednesday) typically save 15&ndash;25% compared to weekend flights. Book 45&ndash;75 days in advance for lowest seasonal economy fares.</p>' +
                '</div>';
            var targetP = firstH2.nextElementSibling ? firstH2.nextElementSibling.nextElementSibling : null;
            if (targetP) {
                firstH2.parentNode.insertBefore(insightsBox, targetP);
            } else {
                firstH2.parentNode.insertBefore(insightsBox, firstH2.nextSibling);
            }
        }
    }

    // 6. Enhance FAQs into interactive accordions with numbered badges
    var faqHeader = document.getElementById("sec-faq");
    if (!faqHeader) {
        var headings = col.querySelectorAll("h2, h3");
        headings.forEach(function (h) {
            if (h.textContent.toLowerCase().indexOf("frequently asked questions") !== -1) {
                faqHeader = h;
            }
        });
    }

    if (faqHeader && !faqHeader.parentNode.querySelector(".faq-section-wrapper")) {
        var faqItems = [];
        var curr = faqHeader.nextElementSibling;
        var currentQ = null;
        var currentAParagraphs = [];

        while (curr) {
            var tagName = curr.tagName.toLowerCase();
            if (tagName === "script") {
                curr = curr.nextElementSibling;
                continue;
            }
            if (tagName === "h3" && (curr.textContent.trim().indexOf("Q") === 0 || curr.textContent.indexOf("?") !== -1)) {
                if (currentQ) {
                    faqItems.push({ q: currentQ, a: currentAParagraphs });
                }
                currentQ = curr;
                currentAParagraphs = [];
            } else if (currentQ && (tagName === "p" || tagName === "ul" || tagName === "div")) {
                currentAParagraphs.push(curr);
            } else if (tagName === "h2") {
                break;
            }
            curr = curr.nextElementSibling;
        }
        if (currentQ) {
            faqItems.push({ q: currentQ, a: currentAParagraphs });
        }

        if (faqItems.length > 0) {
            var accordionWrapper = document.createElement("div");
            accordionWrapper.className = "faq-section-wrapper";

            faqItems.forEach(function (item, index) {
                var card = document.createElement("div");
                card.className = "faq-card-item" + (index === 0 ? " active" : "");

                var qNum = (index + 1) < 10 ? "0" + (index + 1) : (index + 1);
                // Strip existing "Q1:" or "Q2:" from question text if present
                var qCleanText = item.q.innerHTML.replace(/^Q\d+\s*:\s*/i, "").trim();

                var qBtn = document.createElement("button");
                qBtn.type = "button";
                qBtn.className = "faq-question-btn";
                qBtn.innerHTML = 
                    '<span style="display: flex; align-items: center; gap: 6px;">' +
                        '<span class="faq-num-badge">Q' + qNum + '</span>' +
                        '<span>' + qCleanText + '</span>' +
                    '</span>' +
                    '<div class="faq-question-icon"><i class="fa-solid fa-chevron-down"></i></div>';

                var aPanel = document.createElement("div");
                aPanel.className = "faq-answer-panel";
                
                // Physically move original answer paragraphs into accordion panel
                item.a.forEach(function (pElem) {
                    aPanel.appendChild(pElem);
                });

                qBtn.addEventListener("click", function () {
                    var isActive = card.classList.contains("active");
                    accordionWrapper.querySelectorAll(".faq-card-item").forEach(function (c) {
                        c.classList.remove("active");
                    });
                    if (!isActive) {
                        card.classList.add("active");
                    }
                });

                card.appendChild(qBtn);
                card.appendChild(aPanel);
                accordionWrapper.appendChild(card);

                // Completely remove the original h3 from the DOM so it cannot appear twice
                if (item.q.parentNode) {
                    item.q.parentNode.removeChild(item.q);
                }
            });

            faqHeader.parentNode.insertBefore(accordionWrapper, faqHeader.nextElementSibling);
        }
    }

    // 7. Add Trust Strip and CTA Banner if route page
    if (isRoutePage && !col.querySelector(".route-cta-banner")) {
        var trustStrip = document.createElement("div");
        trustStrip.className = "trust-strip-grid";
        trustStrip.innerHTML = 
            '<div class="trust-item">' +
                '<div class="trust-item-icon"><i class="fa-solid fa-shield-halved"></i></div>' +
                '<div>' +
                    '<div class="trust-item-title">Price Match Guarantee</div>' +
                    '<p class="trust-item-desc">We scan 500+ global airlines to find the lowest possible flight fares.</p>' +
                '</div>' +
            '</div>' +
            '<div class="trust-item">' +
                '<div class="trust-item-icon"><i class="fa-solid fa-headset"></i></div>' +
                '<div>' +
                    '<div class="trust-item-title">24/7 Expert Support</div>' +
                    '<p class="trust-item-desc">Live flight booking assistance whenever you need help or changes.</p>' +
                '</div>' +
            '</div>' +
            '<div class="trust-item">' +
                '<div class="trust-item-icon"><i class="fa-solid fa-lock"></i></div>' +
                '<div>' +
                    '<div class="trust-item-title">100% Secure Checkout</div>' +
                    '<p class="trust-item-desc">Industry-standard 256-bit encryption protects every transaction.</p>' +
                '</div>' +
            '</div>' +
            '<div class="trust-item">' +
                '<div class="trust-item-icon"><i class="fa-solid fa-ticket"></i></div>' +
                '<div>' +
                    '<div class="trust-item-title">Instant E-Tickets</div>' +
                    '<p class="trust-item-desc">Receive your official airline itinerary & booking confirmation in minutes.</p>' +
                '</div>' +
            '</div>';

        var ctaBanner = document.createElement("div");
        ctaBanner.className = "route-cta-banner";
        ctaBanner.innerHTML = 
            '<div class="route-cta-content">' +
                '<h4>Need Help Booking This Route?</h4>' +
                '<p>Our flight specialists can access unpublished private partner fares and assist with multi-city or group bookings.</p>' +
            '</div>' +
            '<div class="route-cta-actions">' +
                '<a href="tel:+18332636016" class="btn-cta-call"><i class="fa-solid fa-phone"></i> +1-833-263-6016</a>' +
                '<a href="#flight_submit" class="btn-cta-search" onclick="window.scrollTo({top: 0, behavior: \'smooth\'}); return false;"><i class="fa-solid fa-arrow-up"></i> Search Deals</a>' +
            '</div>';

        col.appendChild(trustStrip);
        col.appendChild(ctaBanner);
    }
});

// Smooth scroll helper for quick navigation pills
window.jumpSection = function (id, e) {
    if (e) e.preventDefault();
    var target = document.getElementById(id);
    if (target) {
        var top = target.getBoundingClientRect().top + window.pageYOffset - 80;
        window.scrollTo({ top: top, behavior: "smooth" });
        document.querySelectorAll(".route-nav-pill").forEach(function(p) { p.classList.remove("active"); });
        if (e && e.currentTarget) e.currentTarget.classList.add("active");
    }
};
