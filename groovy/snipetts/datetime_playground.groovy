import java.time.LocalDateTime
import java.time.ZonedDateTime
import java.time.format.DateTimeFormatter

def localDateTime = ZonedDateTime.parse("2000-01-01T00:09:00+09:00")

assert "Jan 01 (Sat)" == DateTimeFormatter.ofPattern("MMM dd (EEE)", Locale.ENGLISH).format(localDateTime);
assert 946652940000L == localDateTime.toInstant().toEpochMilli()
