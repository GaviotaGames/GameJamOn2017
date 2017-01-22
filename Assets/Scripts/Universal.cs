using System;

public class Universal {
  public static bool isNightTime() {
    return System.DateTime.Now.Hour <= 6 || System.DateTime.Now.Hour >= 21;
  }
}