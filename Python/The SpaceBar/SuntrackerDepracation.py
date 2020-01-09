    path('space_exploration/', include('explorationTimeline.urls')),# call the app explorationTimeline
    path('cafe/', include('cafe.urls')),
    # path('suntracker/', include('suntracker.urls')),  rr removed 11-5-19 story 5382, replaced with my_Location
    path('subscribe/', include('subscribe.urls')),
    path('objectFinder/', include('objectFinder.urls')),
