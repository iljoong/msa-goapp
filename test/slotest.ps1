# slotest -server "52.231.204.54"
# call 100 requests and print stats: avg, max, min, std, slo
param (
    [string]$server = "localhost:8888"
 )

$total = 0;
$min = 10000000;
$max = 0;
$array = @()

# get avg, max, min
for ($i = 0; $i -lt 100; $i++)
{
    $res = Invoke-WebRequest -uri http://localhost:8888/api/test | ConvertFrom-Json

    $array = $array + $res.time

    $total += $res.time
    if ($res.time -lt $min) {
        $min = $res.time
    }
    if ($res.time -gt $max ) {
        $max = $res.time
    }

}

$avg = $total / 100

# get std
for ($i = 0; $i -lt 100; $i++)
{
    $sum =+ (($array[$i] - $avg)*($array[$i] - $avg))
}

$std = [System.Math]::Sqrt($sum / 100)

# get sla, just count where time is ge 100
$slo = 0
for ($i = 0; $i -lt 100; $i++)
{
    if ($array[$i] -ge 100)
    {
        $slo++
    }
}

Write-Host "$avg, $max, $min, $std, $slo"
