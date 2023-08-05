CREATE OR REPLACE TABLE raw(
    driver_id varchar(10),
    game_connected boolean, -- #NO
    game_gameName varchar(3), -- #NO
    game_paused boolean, -- #NO

    game_time datetime, 
    game_timescale smallint(2),
    game_nextRestStopTime datetime,
    game_version varchar(10), -- #NO
    game_telemetryPluginVersion varchar(10), -- #NO

    truck_id varchar(10), -- #NO
    truck_make varchar(30), 
    truck_model varchar(30),
    truck_speed float(5,2),
    truck_cruiseControlSpeed float(5,2),
    truck_cruiseControlOn boolean,
    truck_odometer float(12,3),
    truck_gear smallint(2),
    truck_displayedGear smallint(2),
    truck_forwardGears smallint(2), -- #NO
    truck_reverseGears smallint(2), -- #NO
    truck_shifterType varchar(15), -- #NO
    truck_engineRpm float(6,2),
    truck_engineRpmMax float(6,2), -- #NO
    truck_fuel float(6,2),
    truck_fuelCapacity float(6,2),
    truck_fuelAverageConsumption float(6,2),
    truck_fuelWarningFactor float(3,2), -- #NO
    truck_fuelWarningOn boolean,
    truck_wearEngine float(6,5),
    truck_wearTransmission float(6,5),
    truck_wearCabin float(6,5),
    truck_wearChassis float(6,5),
    truck_wearWheels float(6,5),
    truck_userSteer float(4,2),
    truck_userThrottle float(4,2),
    truck_userBrake float(4,2),
    truck_userClutch float(4,2),
    truck_gameSteer float(4,2),
    truck_gameThrottle float(6,4),
    truck_gameBrake float(4,2),
    truck_gameClutch float(4,2),
    truck_shifterSlot smallInt(2),
    truck_engineOn boolean,
    truck_electricOn boolean, 
    truck_wipersOn boolean,

    truck_retarderBrake smallInt(2),
    truck_retarderStepCount smallInt(2),
    truck_parkBrakeOn boolean,
    truck_motorBrakeOn boolean, 
    truck_brakeTemperature float(5,2),
    truck_adblue float(6,2),
    truck_adblueCapacity float(4,2),
    truck_adblueAverageConsumption float(5,2),
    truck_adblueWarningOn boolean,
    truck_airPressure float(5,2),
    truck_airPressureWarningOn boolean,
    truck_airPressureWarningValue float(5,2),
    truck_airPressureEmergencyOn boolean,
    truck_airPressureEmergencyValue float(5,2),
    truck_oilTemperature float(5,2),
    truck_oilPressure float(5,2),
    truck_oilPressureWarningOn boolean,
    truck_oilPressureWarningValue float(5,2),
    truck_waterTemperature float(5,2),
    truck_waterTemperatureWarningOn boolean,
    truck_waterTemperatureWarningValue float(5,2),
    truck_batteryVoltage float(5,2),
    truck_batteryVoltageWarningOn boolean,
    truck_batteryVoltageWarningValue float(5,2),
    truck_lightsDashboardValue float(4,2),
    truck_lightsDashboardOn boolean,
    truck_blinkerLeftActive boolean,
    truck_blinkerRightActive boolean,
    truck_blinkerLeftOn boolean,
    truck_blinkerRightOn boolean,
    truck_lightsParkingOn boolean,
    truck_lightsBeamLowOn boolean,
    truck_lightsBeamHighOn boolean,
    truck_lightsAuxFrontOn boolean,
    truck_lightsAuxRoofOn boolean,
    truck_lightsBeaconOn boolean,
    truck_lightsBrakeOn boolean,
    truck_lightsReverseOn boolean,

    truck_placement_x float(10, 4),
    truck_placement_y float(10, 4),
    truck_placement_z float(10, 4),
    truck_placement_heading float(10, 4),
    truck_placement_pitch float(10, 4),
    truck_placement_roll float(10, 4),
    truck_acceleration_x float(8, 6),
    truck_acceleration_y float(8, 6),
    truck_acceleration_z float(8, 6),
    truck_head_x  float(8, 6),
    truck_head_y float(8, 6),
    truck_head_z float(8, 6),
    truck_cabin_x float(4, 2),
    truck_cabin_y float(4, 2),
    truck_cabin_z float(4, 2),
    truck_hook_x float(8, 6),
    truck_hook_y float(8, 6),
    truck_hook_z float(8, 6),
    
    trailer_attached boolean,
    trailer_id varchar(20),
    trailer_name varchar(20),
    trailer_mass float(5,2),
    trailer_wear float(12,9),

    trailer_placement_x float(9, 6),
    trailer_placement_y float(9, 6),
    trailer_placement_z float(9, 6),
    trailer_placement_heading float(9, 6),
    trailer_placement_pitch float(9, 6),
    trailer_placement_roll float(9, 6),

    job_income float(8,2),
    job_deadlineTime datetime,
    job_remainingTime datetime,
    job_sourceCity varchar(20),
    job_sourceCompany varchar(20),
    job_destinationCity varchar(20),
    job_destinationCompany varchar(20),

    estimatedTime datetime,
    estimatedDistance smallInt(10),
    speedLimit smallInt(3),

    inserted_date datetime Default CURRENT_TIMESTAMP
);

SELECT driver_id, game_time, truck_id, truck_make, truck_speed, truck_cruiseControlSpeed, truck_cruiseControlOn, truck_odometer, truck_gear, truck_engineRpm, truck_engineRpmMax, truck_fuel, truck_fuelCapacity, truck_fuelAverageConsumption, truck_fuelWarningOn, truck_engineOn, truck_electricOn, truck_brakeTemperature, truck_adblue, truck_adblueCapacity, truck_adblueAverageConsumption, truck_adblueWarningOn, job_deadlineTime, job_sourceCity, job_sourceCompany, job_destinationCity, job_destinationCompany
FROM `raw`
where driver_id='20001129'
and inserted_date>="2023-07-15 13:40:12" and inserted_date<='2023-07-17 23:59:59'