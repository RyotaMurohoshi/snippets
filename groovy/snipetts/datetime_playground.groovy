import java.time.LocalDateTime
import java.time.ZonedDateTime
import java.time.format.DateTimeFormatter
import java.time.format.DateTimeFormatter
import java.time.LocalDate
import java.time.Instant
import java.time.ZoneId
import java.time.format.FormatStyle

def localDateTime = ZonedDateTime.parse("2000-01-01T00:09:00+09:00")

assert "Jan 01 (Sat)" == DateTimeFormatter.ofPattern("MMM dd (EEE)", Locale.ENGLISH).format(localDateTime);
assert 946652940000L == localDateTime.toInstant().toEpochMilli()

def date = LocalDate.parse("2016-07-20", DateTimeFormatter.ISO_LOCAL_DATE)

def englishString = DateTimeFormatter.ofLocalizedDate(FormatStyle.FULL).withLocale(Locale.ENGLISH).format(date)
assert englishString == "Wednesday, July 20, 2016"

def japaneseString = DateTimeFormatter.ofLocalizedDate(FormatStyle.FULL).withLocale(Locale.JAPANESE).format(date)
assert japaneseString == "2016年7月20日"

def englishYearMonthString = DateTimeFormatter.ofPattern("MMMM yyyy").withLocale(Locale.ENGLISH).format(date)
assert englishYearMonthString == "July 2016"

def japaneseYearMonthString = DateTimeFormatter.ofPattern("yyyy年MM月").withLocale(Locale.JAPANESE).format(date)
assert japaneseYearMonthString == "2016年07月"

def epochTime = ZonedDateTime.ofInstant(Instant.ofEpochSecond(0), ZoneId.systemDefault());
assert '1970-01-01T09:00:00+09:00[Asia/Tokyo]' == DateTimeFormatter.ISO_DATE_TIME.format(epochTime)
