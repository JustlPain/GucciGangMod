//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;

public class Region
{
    public CloudRegionCode Code;
    public string HostAndPort;
    public int Ping;

    public static CloudRegionCode Parse(string codeAsString)
    {
        codeAsString = codeAsString.ToLower();
        var none = CloudRegionCode.none;
        if (Enum.IsDefined(typeof(CloudRegionCode), codeAsString))
        {
            none = (CloudRegionCode) ((int) Enum.Parse(typeof(CloudRegionCode), codeAsString));
        }
        return none;
    }

    public override string ToString()
    {
        return string.Format("'{0}' \t{1}ms \t{2}", Code, Ping, HostAndPort);
    }
}

