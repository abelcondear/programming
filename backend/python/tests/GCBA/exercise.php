<?php
function CallAPI($method, $url, $data = false)
{
    $curl = curl_init();

    switch ($method)
    {
        case "POST":
            curl_setopt($curl, CURLOPT_POST, 1);

            if ($data)
                curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
            break;
        case "PUT":
            curl_setopt($curl, CURLOPT_PUT, 1);
            break;
        default:
            if ($data)
                $url = sprintf("%s?%s", $url, http_build_query($data));
    }

    // Optional Authentication:
    curl_setopt($curl, CURLOPT_HTTPAUTH, CURLAUTH_BASIC);
    curl_setopt($curl, CURLOPT_USERPWD, "username:password");

    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);

    $result = curl_exec($curl);

    curl_close($curl);

    return $result;
}	

$str_json = CallAPI(
		'GET'
	,	'http://servicios.usig.buenosaires.gob.ar/normalizar/?direccion=' . 
		urlencode('callao y corrientes, caba')
);

$json = json_decode($str_json, true);

$direccion = $json["direccionesNormalizadas"][0]["direccion"];
$altura = $json["direccionesNormalizadas"][0]["altura"];
$cod_calle = $json["direccionesNormalizadas"][0]["cod_calle"];

echo "direccion=" . $direccion;
echo "<br>";
echo "altura=" . $altura;
echo "<br>";
echo "cod_calle=" . $cod_calle;
echo "<br>";
