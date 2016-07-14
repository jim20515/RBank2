1.	安裝兩個套件 
	i. mysql-connector-net-6.8.6.msi
	ii.mysql-visualstudio-plugin-1.1.3.msi

2.Remove the default entityFramework tag in App.config or Web.config
  
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
      <parameters>
        <parameter value="v11.0" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>

3.Add the following entityFramework tag:

  <entityFramework>
    <defaultConnectionFactory type="MySql.Data.Entity.MySqlConnectionFactory, MySql.Data.Entity.EF6" />
    <providers>
      <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6" />
    </providers>
  </entityFramework>

