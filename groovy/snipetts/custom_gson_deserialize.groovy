@Grab('com.google.code.gson:gson:2.6.1')

import groovy.transform.*
import com.google.gson.*
import java.lang.reflect.Type
import java.text.ParseException
import java.text.SimpleDateFormat

class DateDeserializer implements JsonDeserializer<Date> {
    def format = new SimpleDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'")

    @Override
    public Date deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
            throws JsonParseException {
        String timeStamp = json.getAsString()
        try {
            return format.parse(timeStamp)
        } catch (ParseException e) {
            return null
        }
    }
}

@ToString
class Event {
  String title
  Date at
}

Gson gson = new GsonBuilder()
    .registerTypeAdapter(Date.class, new DateDeserializer())
    .create();

String json = """
{
  "title":"Party",
  "at":"2016-08-01T09:00:00Z"
}
"""

Event event = gson.fromJson(json, Event.class);
println event
