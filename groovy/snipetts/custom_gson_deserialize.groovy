@Grab('com.google.code.gson:gson:2.6.1')

import groovy.transform.*
import com.google.gson.*
import java.lang.reflect.Type
import java.text.ParseException
import java.text.SimpleDateFormat
import java.time.format.DateTimeParseException
import java.time.ZonedDateTime

class DateDeserializer implements JsonDeserializer<Date> {
  def format = new SimpleDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'")

  @Override
  public Date deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
          throws JsonParseException {
      try {
          return format.parse(json.getAsString())
      } catch (ParseException e) {
          return null
      }
  }
}

class ZonedDateTimeDeserializer implements JsonDeserializer<ZonedDateTime> {
  @Override
  public ZonedDateTime deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
          throws JsonParseException, DateTimeParseException {
      try {
          return ZonedDateTime.parse(json.getAsString())
      } catch (DateTimeParseException e) {
          return null
      }
  }
}

@ToString
class Event1 {
  String title
  Date at
}

@ToString
class Event0 {
  String title
  ZonedDateTime at
}

Gson gson = new GsonBuilder()
  .registerTypeAdapter(Date.class, new DateDeserializer())
  .registerTypeAdapter(ZonedDateTime.class, new ZonedDateTimeDeserializer())
  .create();

String json = """
{
  "title":"Party",
  "at":"2016-08-01T09:00:00Z"
}
"""

println gson.fromJson(json, Event0.class)
println gson.fromJson(json, Event1.class)