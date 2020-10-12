function LuaExportStart()
    dofile "lua.lua"
    socket = require("socket")
    host = "localhost"
    port = 31950
    c = socket.try(socket.connect(host, port)) -- connect to the listener socket
    c:setoption("tcp-nodelay",true) -- set immediate transmission mode
end

function LuaExportBeforeNextFrame()
end

function LuaExportAfterNextFrame()
end

-- Triggered every tNext seconds --
function LuaExportActivityNextEvent()
    local tNext = t 
    local data = LoGetSelfData()
    
    local heading = LoGetMagneticYaw()
    local airspeed = LoGetTrueAirSpeed()
    local alt = data.Alt
    local lat = data.Lat
    local lon = data.Long

    --send over network as JSON
    socket.try(c:send(string.format(
        "{
            \"coords\": 
            {
                \"latitude\": \"%f\",
                \"longitude\": \"%f\",
            }
            \"Altitude\": \"%f\",
            \"Heading\": \"%f\",
            \"AirSpeed\": \"%f\"
        }\n", lat, lon, alt, heading, airspeed)))
    
    tNext = tNext + 1.0
    return tNext
end

function LuaExportStop()
    socket.try(c:send("quit")) -- to close the listener socket
    c:close()
end
